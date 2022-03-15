using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject owner;
    private BasicStat basicStatOwner;
    private float hitAnimDuration;
    private Player player;
    private Enemy enemy;
    private Animator animator;
    void Awake()
    {
        basicStatOwner = owner.GetComponent<BasicStat>();
        player = owner.GetComponent<Player>();
        enemy = owner.GetComponent<Enemy>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        if (player)
        {
            UpdateAnimClipTimes();
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            player.CauseDamage(coll.gameObject.GetComponent<Enemy>(), basicStatOwner.base_Damage);
        }
    }

    public IEnumerator ActiveColliderWhenAttack()
    {
        this.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(hitAnimDuration);
        this.GetComponent<BoxCollider2D>().enabled = false;
    }
    private void UpdateAnimClipTimes()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "hit":
                    hitAnimDuration = clip.length;
                    break;
                default:
                    break;
            }
        }

    }
}
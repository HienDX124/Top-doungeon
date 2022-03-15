using UnityEngine;
public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
    public static T instance { get; protected set; }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance.gameObject);
            throw new System.Exception("An instance of this singleton already exists.");
        }
        else
        {
            instance = (T)this;
        }
    }
}
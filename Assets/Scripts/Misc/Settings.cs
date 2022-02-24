﻿using UnityEngine;

public static class Settings
{
    // Obscuring Item Fading - ObscuringItemFader
    public const float fadeInSeconds = 0.25f;
    public const float fadeOutSeconds = 0.35f;
    public const float targetAlpha = 0.45f;

    // Inventory
    public static int playerInitialInventoryCapacity = 24;
    public static int playerMaximumInventoryCapacity = 48;

    // Tilemap
    public const float gridCellSize = 1f; // grid cell size in unity units
    public static Vector2 cursorSize = Vector2.one;

    // Player
    public static float playerCentreYOffset = 0.875f;

    // Player movement
    public const float runningSpeed = 9f;
    public const float walkingSpeed = 6f;
    public static float useToolAnimationPause = 0.25f;
    public static float liftToolAnimationPause = 0.4f;
    public static float pickAnimationPause = 0.5f;
    public static float afterUseToolAnimationPause = 0.2f;
    public static float afterLiftToolAnimationPause = 0.4f;
    public static float afterPickAnimationPause = 0.2f;

    // Player animation parameters
    public static int xInput;
    public static int yInput;
    public static int isWalking;
    public static int isRunning;
    public static int toolEffect;
    public static int isUsingToolRight;
    public static int isUsingToolLeft;
    public static int isUsingToolUp;
    public static int isUsingToolDown;
    public static int isLiftingToolRight;
    public static int isLiftingToolLeft;
    public static int isLiftingToolUp;
    public static int isLiftingToolDown;
    public static int isSwingingToolRight;
    public static int isSwingingToolLeft;
    public static int isSwingingToolUp;
    public static int isSwingingToolDown;
    public static int isPickingRight;
    public static int isPickingLeft;
    public static int isPickingUp;
    public static int isPickingDown;

    // Share animation parameters
    public static int idleUp;
    public static int idleDown;
    public static int idleLeft;
    public static int idleRight;

    // Tools
    public const string HoeingTool = "Hoe";
    public const string ChoppingTool = "Axe";
    public const string BreakingTool = "Pickaxe";
    public const string ReapingTool = "Scythe";
    public const string WateringTool = "Watering Can";
    public const string CollectingTool = "Basket";

    // Reaping
    public const int maxCollidersToTestPerReapSwing = 15;
    public const int maxTargetComponentsToDestroyPerReapSwing = 2;

    // Time System
    public const float secondsPerGameSecond = 0.012f;

    // Static constructor
    static Settings()
    {
        // Player animation parameters
        xInput = Animator.StringToHash("xInput");
        yInput = Animator.StringToHash("yInput");

        isWalking = Animator.StringToHash("isWalking");
        isRunning = Animator.StringToHash("isRunning");

        toolEffect = Animator.StringToHash("toolEffect");

        isUsingToolRight = Animator.StringToHash("isUsingToolRight");
        isUsingToolLeft = Animator.StringToHash("isUsingToolLeft");
        isUsingToolUp = Animator.StringToHash("isUsingToolUp");
        isUsingToolDown = Animator.StringToHash("isUsingToolDown");

        isLiftingToolRight = Animator.StringToHash("isLiftingToolRight");
        isLiftingToolLeft = Animator.StringToHash("isLiftingToolLeft");
        isLiftingToolUp = Animator.StringToHash("isLiftingToolUp");
        isLiftingToolDown = Animator.StringToHash("isLiftingToolDown");

        isSwingingToolRight = Animator.StringToHash("isSwingingToolRight");
        isSwingingToolLeft = Animator.StringToHash("isSwingingToolLeft");
        isSwingingToolUp = Animator.StringToHash("isSwingingToolUp");
        isSwingingToolDown = Animator.StringToHash("isSwingingToolDown");

        isPickingRight = Animator.StringToHash("isPickingRight");
        isPickingLeft = Animator.StringToHash("isPickingLeft");
        isPickingUp = Animator.StringToHash("isPickingUp");
        isPickingDown = Animator.StringToHash("isPickingDown");

        // Share animtion parameters
        idleUp = Animator.StringToHash("idleUp");
        idleDown = Animator.StringToHash("idleDown");
        idleLeft = Animator.StringToHash("idleLeft");
        idleRight = Animator.StringToHash("idleRight");

    }

}

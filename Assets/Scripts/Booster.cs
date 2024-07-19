using UnityEngine;

public class Booster : Item
{
    public static int DropChance = 5;
    private new void Awake()
    {
        base.Awake();
        this.TypeItem = TypeItems.Booster;
    }
}

    
using UnityEngine;

public class PlayerCounter : MonoBehaviour
{
    public static uint BambooCount { get; private set; }

    public static uint BoosterCount { get; private set; }

    public static void BambooCounter()
    {
        BambooCount++;

        Debug.Log("���-�� �������: " + BambooCount);
    }

    public static void BoosterCounter()
    {
        BoosterCount++;

        Debug.Log("���-�� ��������: " + BoosterCount);
    }
}

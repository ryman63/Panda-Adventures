using UnityEngine;
using UnityEngine.UI;

public class DisplayBambooCounter : MonoBehaviour
{
    [SerializeField] private Text Counter;
    void Update()
    {
        Counter.text = PlayerCounter.BambooCount.ToString();
    }
}

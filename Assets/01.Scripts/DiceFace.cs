using UnityEngine;

public class DiceFace : MonoBehaviour
{
    [SerializeField] private int faceNum;
    private Dice dice;

    private void Awake()
    {
        dice = GetComponentInParent<Dice>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(dice.Rb.angularVelocity == Vector3.zero)
        {
            dice.SetDiceResult(faceNum);
        }
    }
}

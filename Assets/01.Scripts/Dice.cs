using UnityEngine;


public class Dice : MonoBehaviour
{
    [SerializeField] private float maxForce;

    private float forceX;
    private float forceY;
    private float forceZ;

    private int diceResultNum;

    private Rigidbody rb;
    private Vector3 startPos;

    #region 프로퍼티
    public int DiceResultNum => diceResultNum;
    public Rigidbody Rb => rb;
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.isKinematic = true;
        startPos = transform.position;

        transform.rotation = new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), 0);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RollDice();
        }

        Debug.Log(DiceResultNum);
    }

    private void RollDice()
    {
        diceResultNum = 0;
        transform.position = startPos;
        
        rb.isKinematic = false;
        rb.angularVelocity = Vector3.zero;
        rb.linearVelocity = Vector3.zero;

        forceX = Random.Range((maxForce / 2), maxForce);
        forceY = Random.Range((maxForce / 2), maxForce);
        forceZ = Random.Range((maxForce / 2), maxForce);

        rb.AddTorque(forceX, forceY, forceZ);
    }

    public void SetDiceResult(int num)
    {
        diceResultNum = num;
    }
}

using UnityEngine;

public class ControlSystem : MonoBehaviour
{
    [Header("���ʳt��")]
    [Range(0.5f, 99.9f)]
    public float moveSpeed = 10f;

    [Header("2D ����")]
    public Rigidbody2D rig;

    [Header("�ʵe���")]
    public Animator ani;

    [Header("�]�B�Ѽ�")]
    public string parRun = "�}���Q��";

    private void Awake()
    {
        print("�_���o");
    }

    private void Start()
    {
        moveSpeed = 10f;
    }

    private void Update()
    {
        MoveAndAnimation();
    }

    private void MoveAndAnimation()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rig.velocity = new Vector3(h, v, 0) * moveSpeed;

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        ani.SetBool(parRun, h > 0 || h < 0 || v > 0 || v < 0);
    }
}

using UnityEngine;

public class BasketballController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float bumpForce = 4f;
    public float torqueAmount = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Bump(Vector2 bumpDirection) {
        rb.AddForce(bumpDirection.normalized * bumpForce, ForceMode2D.Impulse);

        float torqueDir = Mathf.Sign(bumpDirection.x);
        rb.AddTorque(-torqueDir * torqueAmount, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

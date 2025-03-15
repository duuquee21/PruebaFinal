using UnityEngine;

public class Disparo : MonoBehaviour
{
    public float speed = 1f;
    public float torque = 1f;
    [SerializeField] Transform SpawnBala;
    [SerializeField] GameObject balaPrefab;
    public Rigidbody rb;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }            
    }

   



    private void FireBullet()
    {
        GameObject bullet = Instantiate(balaPrefab, SpawnBala.position, SpawnBala.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            bulletRigidbody.AddForce(bullet.transform.up * speed);
        }


    }
    
}
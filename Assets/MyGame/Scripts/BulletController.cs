using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 100f;
    Rigidbody rigidB;
    public GameObject bulletPrefab; // prefab Bala
    public Transform firePoint; // ponto de disparo
    public float bulletTimeLife = 15f;
    float bulletTimeCount;
    public float bulletDamage = 10;


    void Start()
    {
        // rigidB = GetComponent<Rigidbody>();
        // // rigidB.linearVelocity = transform.forward * bulletSpeed;
        // // rigidB.AddForce(transform.forward * bulletSpeed);

        // GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // if (rb != null){
        //     rb.linearVelocity = firePoint.forward * bulletSpeed;
        // }

        rigidB = GetComponent<Rigidbody>();
        rigidB.linearVelocity = transform.forward * bulletSpeed;
        Destroy(gameObject, bulletTimeLife);

    }
    void Update()
    {
        Destroy(this.gameObject, bulletTimeLife);
    }
    [PunRPC]
    void BulletDestroy()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider collision)
    {
        //Destroy(this.gameObject);
        if (collision.CompareTag("Player") && collision.GetComponent<PlayerController>() && !collision.GetComponent<PhotonView>().IsMine)
        {
            Debug.Log("Player_ID " + collision.GetComponent<PhotonView>().Owner.ActorNumber + "Player_Name " + collision.GetComponent<PhotonView>().Owner.NickName);

            collision.GetComponent<PlayerController>().TakeDamage(-bulletDamage);
            collision.GetComponent<PlayerController>();
            this.GetComponent<PhotonView>().RPC("BulletDestroy", RpcTarget.AllViaServer);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Colliders")
        {
            //Destroy(this.gameObject);
            this.GetComponent<PhotonView>().RPC("BulletDestroy", RpcTarget.AllViaServer);
        }        
    }


}

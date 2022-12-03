using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Player
    private Camera _playerCamera;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float attackRange = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _playerCamera.transform.position) > attackRange)
        {
            FollowPlayer();
        }
    }
    
    void FollowPlayer()
    {
        // flatten transform
        Vector3 playerPos = _playerCamera.transform.position;
        playerPos.y = transform.position.y;
        transform.LookAt(playerPos);
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
        // transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
        // transform.LookAt(playerPos);
    }
    
    // Enables or disables the Ragdoll
    public void TurnIntoRagDoll(bool value)
    {
        var rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = !value;
        }
    }

    public void Kill(RaycastHit hitLocationInfo)
    {
        var animator = GetComponent<Animator>();
        animator.enabled = false;
        
        TurnIntoRagDoll(true);
        
        var hitPoint = hitLocationInfo.point;
        var colliders = Physics.OverlapSphere(hitPoint, 0.5f);
        
        foreach (var subCollider in colliders)
        {
            var rb = subCollider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(1000f, hitPoint, 0.5f);
            }
        }
        
        Destroy(gameObject, 5f);
    }
}

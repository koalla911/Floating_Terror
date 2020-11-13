using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotWeapon : Weapon
{
    [SerializeField] private Vector3 projectileSpawnPosition;

    public Vector3 ProjectileSpawnPosition { get; set; }
    public ObjectPooler Pooler { get; set; }
    private Vector3 projectileSpawnValue;
    private void Start()
    {
        projectileSpawnValue = projectileSpawnPosition;
        projectileSpawnValue.y = -projectileSpawnValue.y;

        Pooler = GetComponent<ObjectPooler>();
    }

    
    protected override void Update()
    {
        
    }

    protected override void RequestShot()
    {
        base.RequestShot();
    }

    private void SpawnProjectile(Vector2 spawnPosition)
    {

    }

    private void EvaluateProjectileSpawnPosition()
    {
        if (WeaponOwner.GetComponent<RobotFlip>().FacingUp)
        {
            ProjectileSpawnPosition = transform.position + transform.rotation * projectileSpawnPosition;
        }

        else 
        {
            ProjectileSpawnPosition = transform.position - transform.rotation * projectileSpawnValue;

        }


    }

    private void OnDrawGizmosSelected()
    {
        EvaluateProjectileSpawnPosition();

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(ProjectileSpawnPosition, 0.1f);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    [SerializeField] private GameObject reticlePrefab;

    public float CurrentAimAngleAbsolute { get; set; }
    public float CurrentAimAngle { get; set; }

    private Camera mainCamera;
    private GameObject reticle;
    private Weapon weapon;



    private Vector3 direction;
    private Vector3 mousePosition;
    private Vector3 reticlePosition;
    private Vector3 currentAim = Vector3.zero;
    private Vector3 currentAimAbsolute = Vector3.zero;
    private Quaternion initialRotation;
    private Quaternion lookRotation;

    private void Start() 
    {
        //Cursor.visible = false;
        weapon = GetComponent<Weapon>();
        mainCamera = Camera.main;
        //reticle = Instantiate(reticlePrefab);

    }

    private void Update() 
    {
        /*GetMousePosition();
        MoveReticle();
        RotateWeapon();*/
        Vector3 mouse_pos = Input.mousePosition;
        Vector3 player_pos = Camera.main.WorldToScreenPoint(this.transform.position);

        mouse_pos.x = mouse_pos.x - player_pos.x;
        mouse_pos.y = mouse_pos.y - player_pos.y;

        float angle = Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler (new Vector3(0, 0, angle - 90));

    }

    /*private void GetMousePosition() 
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = 5f;

        direction = mainCamera.ScreenToViewportPoint(mousePosition);
        direction.z = transform.position.z;
        reticlePosition = direction;

        currentAimAbsolute = direction - transform.position;
        

    }

    private void RotateWeapon()
    {
        lookRotation = Quaternion.Euler(CurrentAimAngle * Vector3.forward);
        transform.rotation = lookRotation;

    }

    private void MoveReticle() 
    {
        reticle.transform.rotation = Quaternion.identity;
        reticle.transform.position = reticlePosition;

    }*/
}

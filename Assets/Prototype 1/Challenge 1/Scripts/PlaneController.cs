using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float forwardSpeed = 25f;
    public float strafeSpeed= 7.5f;
    public float hoverSpeed = 5f;
    public float lookRotateSpeed = 2f;

    public Joystick joystick;
    
    private float activeforwardSpeed, activestrafeSpeed, activehoverSpeed;
    private float forwardAccelaration = 2.5f, strafeAccelaration = 2f, hoverAccelaration = 2f;

    ////Camera rotaion of the ship with the mouse, script
    //private Vector2 lookInput, screenCenter, mouseDistance;
    void Start()
    {

        //screenCenter.x = Screen.width * .2f;
        //screenCenter.y = Screen.height * .2f;
    }

    // Update is called once per frame
    void Update()
    {
        ////Ship Rotation Controls
        //lookInput.x = Input.mousePosition.x;
        //lookInput.y = Input.mousePosition.y;

        //mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.x;
        //mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        //mouseDistance = Vector2.ClampMagnitude(mouseDistance, .5f);

        //transform.Rotate(mouseDistance.y * lookRotateSpeed * Time.deltaTime, mouseDistance.x * lookRotateSpeed * Time.deltaTime, 0f, Space.Self);

        //Movement Controls
        activeforwardSpeed = joystick.Horizontal * forwardSpeed;
        activestrafeSpeed = joystick.Vertical * strafeSpeed;
        activehoverSpeed = Mathf.Lerp(activehoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAccelaration * Time.deltaTime);

        transform.position += transform.forward * activeforwardSpeed * Time.deltaTime;
        transform.position += transform.right * activestrafeSpeed * Time.deltaTime;
        transform.position += transform.up * activehoverSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
        }
    }
}

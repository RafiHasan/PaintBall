using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    public static MousePosition Instance { get; private set; }
    private void FixedUpdate()
    {
        //PointerMovement(mainCamera);
        _ = GetMouseWorldPosition();

    }

    private void Awake()
    {
        Instance = this;
    }

    public void PointerMovement(Camera camera)
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            transform.position = raycastHit.point;
            Debug.Log(raycastHit.point);
        }

    }

    public static Vector3 GetMouseWorldPosition() => Instance.GetMouseWorldPosition_Instance();
    private Vector3 GetMouseWorldPosition_Instance()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            Debug.Log(raycastHit.point);
            return raycastHit.point;
        }
        else
        {
            Debug.Log(Vector3.zero);
            return Vector3.zero;
        }
    }

}

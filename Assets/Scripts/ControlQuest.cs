using UnityEngine;
using UnityEngine.XR;

public class ControlQuest : MonoBehaviour
{
    public GameObject objeto;
    public GameObject VRCONTROL;

    public bool estabaPresionado = false;
    public bool disparada = false;

    public Vector3 direccion;
    public float speed = 5.0f;

    void Update()
    {
        InputDevice control = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        bool presionado = false;
        control.TryGetFeatureValue(CommonUsages.secondaryButton, out presionado);

        if (presionado && !estabaPresionado)
        {
            Accion();
        }

        estabaPresionado = presionado;

        if (disparada)
        {
            objeto.transform.position += direccion * speed * Time.deltaTime;
        }
    }

    public void Accion()
    {
        objeto.transform.position = VRCONTROL.transform.position;
        direccion = VRCONTROL.transform.forward;
        objeto.SetActive(true);
        disparada = true;
    }
}
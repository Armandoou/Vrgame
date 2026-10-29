using UnityEngine;
using UnityEngine.XR;

public class DestroyObject : MonoBehaviour
{
    public string etiqueta = "Destruible";

    private bool estabaPresionado = false;

    void Update()
    {
        InputDevice controlIzq = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);

        bool presionado = false;
        controlIzq.TryGetFeatureValue(CommonUsages.secondaryButton, out presionado);

        if (presionado && !estabaPresionado)
        {
            DestruirTodo();
        }

        estabaPresionado = presionado;
    }

    void DestruirTodo()
    {
        GameObject[] objetos = GameObject.FindGameObjectsWithTag(etiqueta);

        foreach (GameObject obj in objetos)
        {
            Destroy(obj);
        }
    }
}
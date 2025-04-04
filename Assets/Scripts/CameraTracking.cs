using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform carro;
    public Vector3 offset = new Vector3(0, 10, -15);

    void LateUpdate()
    {
        // Atualiza a posição da câmera com base na posição e rotação do carro
        transform.position = carro.position + carro.rotation * offset;

        // Faz a câmera olhar para o carro
        transform.LookAt(carro.position + carro.forward * 15f);
    }
}

using UnityEngine;

public class TelaInicial : MonoBehaviour
{
    public GameObject painelInicio;
    public GameObject painelScore;

    public void IniciarJogo()
    {
        painelInicio.SetActive(false); // Esconde a tela inicial
        painelScore.SetActive(true);
        Time.timeScale = 1f; // Libera o tempo se o jogo estiver pausado
    }

    void Start()
    {
        painelInicio.SetActive(true); // Mostra o painel
        painelScore.SetActive(false);
        Time.timeScale = 0f; // Pausa o jogo até clicar em "Iniciar"
    }
}
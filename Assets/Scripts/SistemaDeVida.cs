using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SistemaDeVida : MonoBehaviour
{
    [SerializeField] private int vida = 100;
    [SerializeField] private Slider vidaIndicador;
    private bool estaVivo = true;
    private bool levarDano = true;
    private Player pMove;

    void Start()
    {
        ProcuraReferencias();
    }

    void Update()
    {
        ProcuraReferencias();
    }

    private void ProcuraReferencias()
    {

        if (vidaIndicador == null)
        {
            vidaIndicador = GameObject.Find("Vida").GetComponent<Slider>();
            vidaIndicador.maxValue = 100;
            vidaIndicador.value = vida;
        }

        if (pMove == null)
        {
            pMove = GetComponent<Player>();
        }
    }

    public bool EstaVivo()
    {
        return estaVivo;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fatal") && estaVivo && levarDano)
        {
            StartCoroutine(LevarDano(10));
        }
    }

    public void TomarDano(int dano)
    {
        if (estaVivo && levarDano)
        {
            StartCoroutine(LevarDano(dano));
        }
    }

    IEnumerator LevarDano(int dano)
    {
        levarDano = false;

        if (vida > 0)
        {
            pMove.Hit(); // Chama o método Hit do PlayerMovement para executar a animação de dano
            vida -= dano;
            vidaIndicador.value = vida;
            VerificarVida();
            yield return new WaitForSeconds(0.5f);
            levarDano = true;
        }
    }

    private void VerificarVida()
    {
        if (vida <= 0)
        {
            vida = 0;
            estaVivo = false;
        }
    }
}
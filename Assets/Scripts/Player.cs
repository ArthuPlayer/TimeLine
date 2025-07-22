using UnityEngine;

public class Movimento2D : MonoBehaviour
{
    public float velocidade = 5f;       // Velocidade de movimento horizontal
    public float forcaPulo = 7f;        // Força do pulo
    private Rigidbody2D rb;             // Referência ao Rigidbody2D
    private bool noChao = false;        // Verifica se o jogador está no chão

    public Transform checadorChao;      // Objeto filho que verifica o chão
    public float raioChao = 0.2f;       // Raio de detecção do chão
    public LayerMask camadaChao;        // Layer que define o que é chão

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // === Movimento Horizontal ===
        // Usa as teclas A (ou ←) para esquerda, D (ou →) para direita
        float movimento = Input.GetAxisRaw("Horizontal"); // -1 (esquerda), 1 (direita), 0 (nenhum)
        rb.velocity = new Vector2(movimento * velocidade, rb.velocity.y);

        // === Checa se está tocando o chão ===
        noChao = Physics2D.OverlapCircle(checadorChao.position, raioChao, camadaChao);

        // === Pulo ===
        // Usa a tecla espaço para pular, mas só se estiver no chão
        if (Input.GetButtonDown("Jump") && noChao)
        {
            rb.velocity = new Vector2(rb.velocity.x, forcaPulo);
        }
    }

    // (Opcional) Visualização no editor da área de detecção do chão
    void OnDrawGizmosSelected()
    {
        if (checadorChao != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(checadorChao.position, raioChao);
        }
    }
}

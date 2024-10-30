using UnityEngine;

public class Ajto : MonoBehaviour
{
    [SerializeField] private Sprite nyitottAjtoSprite;  // Nyitott ajt� sprite
    [SerializeField] private Sprite csukottAjtoSprite;  // Csukott ajt� sprite
    private SpriteRenderer spriteRenderer; // Sprite Renderer az ajt�hoz

    private void Start()
    {
        // Inicializ�ljuk a Sprite Renderert �s a csukott ajt� sprite-j�t �ll�tjuk be
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = csukottAjtoSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ha a j�t�kos triggereli az ajt�t
        if (collision.CompareTag("Player"))
        {
            // Nyitott ajt� sprite-ra v�lt�s
            spriteRenderer.sprite = nyitottAjtoSprite;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Ha a j�t�kos elhagyja a trigger z�n�t, csukott ajt�ra v�lt�s
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.sprite = csukottAjtoSprite;
        }
    }
}

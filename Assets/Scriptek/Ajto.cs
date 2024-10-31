using UnityEngine;

public class Ajto : MonoBehaviour
{
    [SerializeField] private Sprite nyitottAjtoSprite;  // Nyitott ajt� sprite
    [SerializeField] private Sprite csukottAjtoSprite;  // Csukott ajt� sprite
    [SerializeField] private GameObject enemyPrefab;    // Az ellens�g prefabja
    [SerializeField] private Transform spawnPoint;      // Az ellens�g spawn helye
    [SerializeField] private float spawnEsely = 0.25f;  // Spawn es�ly (25%)

    private SpriteRenderer spriteRenderer; // Sprite Renderer az ajt�hoz
    private bool nyitva = false; // Annak nyilv�ntart�sa, hogy az ajt� nyitott-e

    private void Start()
    {
        // Inicializ�ljuk a Sprite Renderert �s be�ll�tjuk a csukott ajt� sprite-j�t
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = csukottAjtoSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ha a j�t�kos bel�p az ajt� trigger�be, kinyitjuk az ajt�t
        if (collision.CompareTag("Player") && !nyitva)
        {
            NyisdKiAjtot();
            nyitva = true; // Megakad�lyozza az ajt� t�bbsz�ri kinyit�s�t
        }
    }

    private void NyisdKiAjtot()
    {
        // Nyitott ajt� sprite-ra v�lt�s
        spriteRenderer.sprite = nyitottAjtoSprite;

        // Spawn es�ly ellen�rz�se
        if (Random.value < spawnEsely)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        // Debug log az ellens�g spawn-ol�s�n�l
        Debug.Log("Pr�b�lja spawnolni az ellens�get.");

        if (enemyPrefab != null && spawnPoint != null)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("Ellens�g spawnol�sa sikeres.");
        }
        else
        {
            Debug.LogWarning("Hi�nyz� enemyPrefab vagy spawnPoint.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Amikor a j�t�kos elhagyja a trigger ter�letet, vissza�ll�tja az ajt�t csukott �llapotra
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.sprite = csukottAjtoSprite;
            nyitva = false; // Enged�lyezi az ajt� �jb�li kinyit�s�t, ha �jra bel�p
        }
    }
}

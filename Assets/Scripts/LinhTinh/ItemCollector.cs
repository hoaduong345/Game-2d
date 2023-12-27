
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    [SerializeField] private Text cherriesText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void Awake()
    {
        cherries = Shared.scores;
        cherriesText.text = "Scores:" + cherries.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            Shared.scores = cherries;
            cherriesText.text = "Scores:" + cherries.ToString();

        }

        if (collision.gameObject.tag == "DeadPoint")
        {
           
            string nameNam = collision.gameObject.transform.parent.name;
            Destroy(GameObject.Find(nameNam));
            cherries++;
            Shared.scores = cherries;           
            cherriesText.text = "Scores:" + cherries.ToString();

        }
    }
   

}

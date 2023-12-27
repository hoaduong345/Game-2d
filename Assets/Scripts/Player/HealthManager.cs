
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    public static float health = 3;
    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emtyHearts;

    private void Awake()
    {
      if(Shared.heart != 0)
        {
            health= Shared.heart;
        }
       
    }

    private void Update()
    {

        foreach (Image img in hearts)
        {
            img.sprite = emtyHearts;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHearts;
        }

        if(health != 3)
        {
            Shared.heart = health;
        }
    }

}

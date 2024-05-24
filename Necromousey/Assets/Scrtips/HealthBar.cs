using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   public Slider slider;
   public Gradient gradient;
   public Image fill;

   public void SetMaxHelath(int helath)
   {
        slider.maxValue = helath;
        slider.value = helath;

        fill.color = gradient.Evaluate(1f);
   }
   public void SetHealth (int health)
   {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
   }

}

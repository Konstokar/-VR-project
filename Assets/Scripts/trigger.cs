using UnityEngine;

public class trigger : MonoBehaviour
{
    public int clutterLevel = 0; // начальный уровень захламленности
    public int clutterIncrement = 1; // на сколько увеличивается уровень при отсутствии предметов
    public float checkInterval = 1f; // интервал проверки (в секундах)

    private bool hasItemInCollider = false; // флаг, находится ли предмет в коллайдере

    void Start()
    {
        // Запускаем проверку на отсутствие предметов в интервале checkInterval
        InvokeRepeating("CheckForClutter", checkInterval, checkInterval);
    }

    void OnTriggerEnter(Collider other)
    {
        // Проверяем, является ли объект тем, который мы отслеживаем (например, по тэгу)
        if (other.CompareTag("TrackedItem"))
        {
            hasItemInCollider = true; // предмет в коллайдере
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TrackedItem"))
        {
            hasItemInCollider = false; // предмет покинул коллайдер
        }
    }

    void CheckForClutter()
    {
        // Если предмет отсутствует, увеличиваем уровень захламленности
        if (!hasItemInCollider)
        {
            clutterLevel += clutterIncrement;
            Debug.Log("Уровень захламленности увеличен: " + clutterLevel);
        }
    }
}
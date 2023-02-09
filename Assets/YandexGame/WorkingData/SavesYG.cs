
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;


        public int currentCar = 0;
        public int money = 0;
        public int currentLevel = 1;
        public int levelCount = 20;
        public bool[] carsUnlocked = new bool[6];
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива


            // Длина массива в проекте должна быть задана один раз!
            // Если после публикации игры изменить длину массива, то после обновления игры у пользователей сохранения могут поломаться
            // Если всё же необходимо увеличить длину массива, сдвиньте данное поле массива в самую нижнюю строку кода
        }
    }
}

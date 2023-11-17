namespace TodoStudent.Shared.Extensions;

public static class IntExtension
{
    /// <summary>
    /// Возвращает слова в падеже, зависимом от заданного числа
    /// </summary>
    /// <param name="number">Число от которого зависит выбранное слово</param>
    /// <param name="nominativ">Именительный падеж слова. Например "день"</param>
    /// <param name="genetiv">Родительный падеж слова. Например "дня"</param>
    /// <param name="plural">Множественное число слова. Например "дней"</param>
    /// <returns></returns>
    public static string GenerateDeclension(this int number, string nominativ, string genetiv, string plural)
    {
        var titles = new[] { nominativ, genetiv, plural };
        var cases = new[] { 2, 0, 1, 1, 1, 2 };
        return titles[
            Math.Abs(number) % 100 > 4 && Math.Abs(number) % 100 < 20
                ? 2
                : cases[(Math.Abs(number) % 10 < 5) ? Math.Abs(number) % 10 : 5]];
    }

    /// <summary>
    /// Возвращает логический статус: четное число или нет.
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static bool IsEven(this int number)
    {
        if ((number % 2) == 0)
        {
            return true;
        }
 
        return false;
    }
}
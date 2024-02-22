var width = Console.WindowWidth;
var height = Console.WindowHeight;
var rand = new Random();

Console.CursorVisible = false;
var y = new int[width];

for (var x = 0; x < width; ++x) y[x] = rand.Next(height);

while (true)
{
    for (var x = 0; x < width; ++x)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(x, y[x]);
        Console.Write(GetRandomChar());

        var temp = y[x] - 2;
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.SetCursorPosition(x, InScreenY(temp));
        Console.Write(GetRandomChar());

        var temp2 = y[x] - 20;
        Console.SetCursorPosition(x, InScreenY(temp2));
        Console.Write(' ');

        y[x] = InScreenY(y[x] + 1);
    }

    Thread.Sleep(30);
}

char GetRandomChar()
{
    var t = rand.Next(10);
    return t switch
    {
        <= 2 => (char)('0' + rand.Next(10)),
        <= 4 => (char)('a' + rand.Next(27)),
        <= 6 => (char)('A' + rand.Next(27)),
        _ => (char)(rand.Next(32, 255))
    };
}

int InScreenY(int y)
{
    if (y < 0) return (y % height + height) % height;
    return y % height;
}
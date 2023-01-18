using Raylib_cs;

Raylib.InitWindow(1200, 800, "Dodging game");
Raylib.SetTargetFPS(60);




Texture2D playerImage = Raylib.LoadTexture("Mario.png");
// Texture2D bkgImage = Raylib.LoadTexture("Test2.png");
Texture2D enemyImage = Raylib.LoadTexture("spikeBall.png");
Rectangle playerRect = new Rectangle(Raylib.GetScreenWidth(), 210, playerImage.width, playerImage.height);
Rectangle enemyRect = new Rectangle(100, 100, enemyImage.width, enemyImage.height);
//Glöm inte berätta din hitbox problem du har stött på

int[] xPosition = { 0, 400, 800, 1100 };

Random gen = new();

// int x = xPosition[0];
int i = gen.Next(xPosition.Length);
int x = xPosition[i];

int x = xPosition[gen.Next(xPosition.Length)];


List<Rectangle> enemyRects = new List<Rectangle>(); // Använder "List" så att jag inte behöver upprepa alla rektanglar och köra det enskilt.



enemyRects.Add(new Rectangle(0, -400, enemyImage.width, enemyImage.height));
enemyRects.Add(new Rectangle(400, -400, enemyImage.width, enemyImage.height));
enemyRects.Add(new Rectangle(800, -400, enemyImage.width, enemyImage.height));
enemyRects.Add(new Rectangle(1100, -400, enemyImage.width, enemyImage.height));




float speed = 9f;

string currentScene = "start";

while (!Raylib.WindowShouldClose())
{
    // Logik

    if (currentScene == "game")
    {
        for (int i = 0; i < enemyRects.Count; i++)
        //kör lika många gånger som det är grejer i listan, ett värde börjar på noll och i slutet ökas "i" med ett 1
        {
            Rectangle rect = enemyRects[i];
            rect.y += 5;

            enemyRects[i] = rect;
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            playerRect.x += speed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            playerRect.x -= speed;
        } // Gör så att du kan styra din karaktär genom att trycka på A och D i två olika håll på X leden av en graf

        if (Raylib.CheckCollisionRecs(playerRect, enemyRect))
        {
            currentScene = "end";
        }
    }
    else if (currentScene == "start")
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
        {
            currentScene = "game";
        }
    }

    // Grafik
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);

    if (currentScene == "game")
    {


        foreach (Rectangle rect in enemyRects) //Kommer köra lika många gånger som det finns grejer i en lista
        {
            Raylib.DrawTexture(enemyImage, (int)rect.x, (int)rect.y, Color.WHITE);
        }
        Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
        // Raylib.DrawTexture(bkgImage, 0, 0, Color.WHITE);
    }

    else if (currentScene == "start")
    {
        Raylib.DrawText("Innan du börjar läs efter följande:", 100, 100, 50, Color.BLACK);
        Raylib.DrawText("Du styr din karaktär genom att trycka på A (vänster) och D (höger)", 100, 200, 30, Color.BLACK);
        Raylib.DrawText("Försök undvik fallande objekt och överlev så länge som möjligt", 100, 300, 30, Color.BLACK);
        Raylib.DrawText("Tryck på ENTER för att starta", 100, 400, 50, Color.BLACK);
    }
    else if (currentScene == "end")
    {
        Raylib.DrawText("GG", 500, 500, 50, Color.BLACK);
    }

    Raylib.EndDrawing();
}
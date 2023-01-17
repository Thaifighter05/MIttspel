using Raylib_cs;

Raylib.InitWindow(1280, 720, "Dodging game");
Raylib.SetTargetFPS(60);




Texture2D playerImage = Raylib.LoadTexture("Mario.png");
// Texture2D bkgImage = Raylib.LoadTexture("Test2.png");
Texture2D enemyImage = Raylib.LoadTexture("spikeBall.png");
Rectangle playerRect = new Rectangle(210, 210, playerImage.width, playerImage.height);
Rectangle enemyRect = new Rectangle(100,100, enemyImage.width, enemyImage.height);


List<Rectangle> enemyRects = new List<Rectangle>();
enemyRects.Add(new Rectangle(0,-400, enemyImage.width, enemyImage.height));
enemyRects.Add(new Rectangle(400,-400, enemyImage.width, enemyImage.height));
enemyRects.Add(new Rectangle(800,-400, enemyImage.width, enemyImage.height));
enemyRects.Add(new Rectangle(1100,-400, enemyImage.width, enemyImage.height));




float speed = 5.5f;

string currentScene = "start"; 

while (!Raylib.WindowShouldClose())
{
  // Logik
 
  if (currentScene == "game")
  {
    for(int i = 0; i < enemyRects.Count; i++ ) 
    //kör lika många gånger som det är grejer i listan, ett värde börjar på noll och i slutet ökas "i" med ett 1
    {
      Rectangle rect = enemyRects[i];
      rect.y+=5;
      enemyRects[i] = rect;
    }// st

    if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
    {
      playerRect.x += speed;
    }
    else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
    {
      playerRect.x -= speed;
    } // Gör så att du kan styra din karaktär genom att trycka på A och D i två olika håll på X leden av en graf
  
    //  if (Raylib.CheckCollisionRecs(playerRect, enemyRect))
    //  {
    //    currentScene = "end";
    // }
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

    
    foreach (Rectangle rect in enemyRects)
    {
         Raylib.DrawTexture(enemyImage, (int)rect.x, (int)rect.y, Color.WHITE);
    }
        Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
        // Raylib.DrawTexture(bkgImage, 0, 0, Color.WHITE);
  }

  else if (currentScene == "start") 
  {
    Raylib.DrawText("Du styr din karaktär genom att trycka på A (vänster) och D (höger)", 100,400,30,Color.BLACK);
    Raylib.DrawText("Tryck på ENTER för att starta", 100, 560, 50, Color.BLACK);
  }
  else if (currentScene == "end")
  {
    Raylib.DrawText("GG", 500, 500, 50, Color.BLACK);
  }

  Raylib.EndDrawing();
}
using Raylib_cs;
 Raylib.InitWindow(1000, 1000, "Space Shooter");
 Raylib.SetTargetFPS(60);

//Variabler för Spel
float backGroundScrollSpeed = 3;
float playerShipSpeed = 7.5f;
float enemySpeed = 2;
float bulletSpeed = 15;



//Texturer genom att använda "Texture2D "Namn" = Raylib.LoadTexture("Fil.namn");"
Texture2D playerShip = Raylib.LoadTexture("Placeholder.png");
Texture2D easyEnemy = Raylib.LoadTexture("");
Texture2D mediumEnemy = Raylib.LoadTexture("");
Texture2D hardEnemy = Raylib.LoadTexture("");
Texture2D bossEnemy = Raylib.LoadTexture("");
Texture2D backGround = Raylib.LoadTexture("");
Texture2D guiCoin = Raylib.LoadTexture("");

//Hitboxes genom "Rectangle "namn" = new Rectangle(posx, posy, sizex, sizey);"
Rectangle playerHitbox = new Rectangle(500, 500, 100, 100);




while (Raylib.WindowShouldClose() == false) {

    //rörelse 
    if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            playerHitbox.x += playerShipSpeed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            playerHitbox.x -= playerShipSpeed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
        {
            playerHitbox.y += playerShipSpeed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
        {
            playerHitbox.y -= playerShipSpeed;
        }

    Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.GRAY);

        //rita texturer på rektanglar genom "Raylib.DrawTexture(textureInt, (int)rect.x, (int)rect.y, Color.COLOR);"
        Raylib.DrawTexture(playerShip, (int)playerHitbox.x, (int)playerHitbox.y, Color.WHITE);



    Raylib.EndDrawing();

 }
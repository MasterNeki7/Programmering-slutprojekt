using Raylib_cs;
Raylib.InitWindow(1000, 1000, "Space Shooter");
Raylib.SetTargetFPS(60);

//Variabler för Spel
float backGroundScrollSpeed = 5;

float playerShipSpeed = 7.5f;

float easyEnemySpeed = 2;
float mediumEnemySpeed = 4;
float hardEnemySpeed = 6;
float enemyProjectileSpeed = 7.5f;

string scene = "startMenu";

List<projectile> playerProjectilesList = new List<projectile>();



//Texturer genom att använda "Texture2D "Namn" = Raylib.LoadTexture("Fil.namn");"
Texture2D playerShip = Raylib.LoadTexture("Placeholder.png");

Texture2D easyEnemy = Raylib.LoadTexture("easyEnemy.png");
Texture2D mediumEnemy = Raylib.LoadTexture("mediumEnemy.png");
Texture2D hardEnemy = Raylib.LoadTexture("hardEnemy.png");
Texture2D bossEnemy = Raylib.LoadTexture("");
Texture2D enemyProjectile = Raylib.LoadTexture("");

Texture2D backGround1 = Raylib.LoadTexture("bkg.png");
Texture2D backGround2 = Raylib.LoadTexture("bkg.png");

Texture2D powerPowerUp = Raylib.LoadTexture("");
Texture2D shotsPowerUp = Raylib.LoadTexture("");
Texture2D hpPowerUp = Raylib.LoadTexture("");
Texture2D spreadPowerUp = Raylib.LoadTexture("");

Texture2D guiCoin = Raylib.LoadTexture("");
Texture2D startScene = Raylib.LoadTexture("");

//Hitboxes genom "Rectangle "namn" = new Rectangle(posx, posy, sizex, sizey);"
Rectangle playerHitbox = new Rectangle(500, 800, playerShip.width, playerShip.height);

Rectangle easyEnemyHitbox = new Rectangle(300, 250, 50, 50);
Rectangle mediumEnemyHitbox = new Rectangle(300, 150, 50, 50);
Rectangle hardEnemyHitbox = new Rectangle(300, 50, 50, 50);
Rectangle enemyProjectileHitbox = new Rectangle(800, 700, 10, 10);


Rectangle bkg1Rect = new Rectangle(0, 0, (int)backGround1.width, (int)backGround1.height);
Rectangle bkg2Rect = new Rectangle(0, -1000, (int)backGround2.width, (int)backGround2.height);


while (Raylib.WindowShouldClose() == false)
{

    if (scene == "startMenu")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
        {
            scene = "gameStart";
        }

    }

    else if (scene == "gameStart")
    {

        //Logik-----------------------------------------------

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

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            playerProjectilesList.Add(new projectile(playerHitbox.x, playerHitbox.y));

        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_TAB))
        {

        }

        foreach (projectile p in playerProjectilesList)
        {
            p.update();

        }




        playerProjectilesList.RemoveAll(p => p.playerProjectileHitbox.y < 0);

        //Kod för att få bakgrunden att skrolla oändligt
        bkg1Rect.y += backGroundScrollSpeed;
        bkg2Rect.y += backGroundScrollSpeed;

        //Kod för att få bakgrunden att loopa
        if (bkg1Rect.y >= 1000)
        {
            bkg1Rect.y = -1000;
        }

        if (bkg2Rect.y >= 1000)
        {
            bkg2Rect.y = -1000;
        }

        //Kod för att inte låta spelaren överskrida skärmens dimensioner
        if (playerHitbox.x >= 900)
        {
            playerHitbox.x = 900;
        }

        else if (playerHitbox.x <= 0)
        {
            playerHitbox.x = 0;
        }

        if (playerHitbox.y >= 900)
        {
            playerHitbox.y = 900;
        }

        else if (playerHitbox.y <= 0)
        {
            playerHitbox.y = 0;
        }



        //Kod för få fiender att åka fram och tillbaka över skärmen
        easyEnemyHitbox.x += easyEnemySpeed;
        if (easyEnemyHitbox.x > 900)
        {
            easyEnemySpeed = -easyEnemySpeed;
        }
        else if (easyEnemyHitbox.x < 0)
        {
            easyEnemySpeed = -easyEnemySpeed;
        }

        mediumEnemyHitbox.x += mediumEnemySpeed;
        if (mediumEnemyHitbox.x > 900)
        {
            mediumEnemySpeed = -mediumEnemySpeed;
        }
        else if (mediumEnemyHitbox.x < 0)
        {
            mediumEnemySpeed = -mediumEnemySpeed;
        }

        hardEnemyHitbox.x += hardEnemySpeed;
        if (hardEnemyHitbox.x > 900)
        {
            hardEnemySpeed = -hardEnemySpeed;
        }
        else if (hardEnemyHitbox.x < 0)
        {
            hardEnemySpeed = -hardEnemySpeed;
        }

    }


    Raylib.BeginDrawing();

    if (scene == "startMenu")
    {
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawText("Play game", 100, 500, 40, Color.BLACK);
        Raylib.DrawText("Press \"ENTER\" to start game", 100, 700, 50, Color.BLACK);

    }

    else if (scene == "gameStart")
    {

        Raylib.ClearBackground(Color.GRAY);

        //rita texturer på rektanglar genom "Raylib.DrawTexture(textureInt, (int)rect.x, (int)rect.y, Color.COLOR);

        Raylib.DrawTexture(backGround1, 0, (int)bkg1Rect.y, Color.WHITE);
        Raylib.DrawTexture(backGround2, 0, (int)bkg2Rect.y, Color.WHITE);


        Raylib.DrawTexture(playerShip, (int)playerHitbox.x, (int)playerHitbox.y, Color.WHITE);
        foreach (projectile p in playerProjectilesList)
        {
            p.draw();
        }

        Raylib.DrawTexture(easyEnemy, (int)easyEnemyHitbox.x, (int)easyEnemyHitbox.y, Color.WHITE);
        Raylib.DrawTexture(mediumEnemy, (int)mediumEnemyHitbox.x, (int)mediumEnemyHitbox.y, Color.WHITE);
        Raylib.DrawTexture(hardEnemy, (int)hardEnemyHitbox.x, (int)hardEnemyHitbox.y, Color.WHITE);

    }



    Raylib.EndDrawing();



}
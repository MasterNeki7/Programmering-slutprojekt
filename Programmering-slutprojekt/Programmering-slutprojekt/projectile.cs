using Raylib_cs;

public class projectile
{
    float playerProjectileSpeed = 15;
    Texture2D playerProjectile = Raylib.LoadTexture("playerProjectile.png");
    public Rectangle playerProjectileHitbox;

    public projectile(float projectilePosX, float projectilePosY) {
        playerProjectileHitbox = new Rectangle(projectilePosX += 40, projectilePosY, playerProjectile.width, playerProjectile.height);

    }

    public void update() {
        playerProjectileHitbox.y -= playerProjectileSpeed;
        
    }

    public void draw () {
        Raylib.DrawTexture(playerProjectile, (int)playerProjectileHitbox.x, (int)playerProjectileHitbox.y, Color.WHITE);
    }
}

using System;

class Program
{
    public static void Main(string[] args)
    {
        Random rand = new Random();
        Humanoid player = new Humanoid();
        player.HP = 100;
        player.attack = 50;
        player.defense = 20;
        player.bonusAttack = (float)rand.NextDouble() * 1;

        Humanoid enemy = new Humanoid();
        enemy.HP = 105;
        enemy.attack = 30;
        enemy.defense = 10;
        enemy.bonusAttack = (float)rand.NextDouble() * 1;

        int input = 0;
        Console.Write("Input Siapa yang mulai mukul duluan 1 = Player, 2 = Enemy. Pilih : ");
        int.TryParse(Console.ReadLine(), out input);

        switch (input)
        {
            default: PlayerMukul(player, enemy); break;
            case 1: PlayerMukul(player, enemy); break;
            case 2: EnemyMukul(player, enemy); break;
        }
    }

    private static void EnemyMukul(Humanoid player, Humanoid enemy)
    {
        if (player.bonusAttack >= 0.25) //Apply Critical Damage
        {
            float criticalDamage = enemy.attack + (enemy.bonusAttack * 100);
            Console.WriteLine("Player menerima damage critical sebesar : " + (int)criticalDamage);
            player.HP -= (int)criticalDamage;
        }
        else
        {
            player.HP -= enemy.attack;
            Console.WriteLine("Player menerima damage : " + enemy.attack);
        }
        if (player.HP < 1) Console.WriteLine("Player Dead"); //HP == 0 Auto Dead
    }
    private static void PlayerMukul(Humanoid player, Humanoid enemy)
    {
        {
            if (player.bonusAttack >= 0.25) //Apply Critical Damage
            {
                float criticalDamage = player.attack + (player.bonusAttack * 100);
                Console.WriteLine("Enemy menerima damage critical sebesar : " + (int)criticalDamage);
                enemy.HP -= (int)criticalDamage;
            }
            else
            {
                enemy.HP -= player.attack;
                Console.WriteLine("Enemy menerima damage : " + player.attack);
            }
            if (enemy.HP < 1) Console.WriteLine("Enemy Dead"); //HP == 0 Auto Dead
        };
    }
}
public class Humanoid
{
    public int HP, attack, defense;
    public float bonusAttack;
}
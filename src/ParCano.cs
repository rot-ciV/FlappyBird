using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

public class ParCano{

    public float VelocidadeX { get; set;}
    public float PosicaoX { get; set;}
    public float Gap { get; set;}
    public float TamanhoGap { get; set;}
    public Texture2D Sprite { get; set;}

    public Rectangle HitboxCima {
        
        get{
            return new Rectangle((int)PosicaoX, 0, 50, (int)Gap);
        }
    }

    public Rectangle HitboxBaixo {
        
        get{
            return new Rectangle((int)PosicaoX, (int)(Gap + TamanhoGap), 50, 300);
        }
    }

    public ParCano(Vector2 posicaoInicial, float velocidadeX, float gap, float tamGap){
        
        PosicaoX = posicaoInicial.X;
        VelocidadeX = velocidadeX;
        Gap = gap;
        TamanhoGap = tamGap;
    }

    public void Update(GameTime gameTime){

        float deltaTempo = (float)gameTime.ElapsedGameTime.TotalSeconds;
        PosicaoX += VelocidadeX * deltaTempo;
    }

    public void Draw(SpriteBatch pintor){

        pintor.Draw(Sprite, HitboxCima, Color.White);
        pintor.Draw(Sprite, HitboxBaixo, Color.White);
    }
}
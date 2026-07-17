using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

public class Priquito{

    public float Gravidade { get; set;}
    public float VelocidadeY { get; set;}
    public float Pulo { get; set;}
    public Rectangle Hitbox { get; set;}
    public Vector2 Posicao { get; set;}
    public KeyboardState EstadoTeclado { get; set;}
    public Texture2D Sprite { get; set;}


    public Priquito(Vector2 posicaoInicial){

        Gravidade = 0.5f;
        VelocidadeY = 0f;
        Pulo = -10f;
        Posicao = posicaoInicial;
        Hitbox = new Rectangle((int)Posicao.X, (int)Posicao.Y, 50, 50);
        EstadoTeclado = Keyboard.GetState();
    }

    public void Update(GameTime gameTime){

        KeyboardState EstadoTecladoAtual = Keyboard.GetState();

        float deltaTempo = (float)gameTime.ElapsedGameTime.TotalSeconds;

        if(EstadoTecladoAtual.IsKeyDown(Keys.Space) && EstadoTeclado.IsKeyUp(Keys.Space)){
            VelocidadeY = Pulo;
        }

        VelocidadeY += Gravidade*deltaTempo;
        Posicao = new Vector2(Posicao.X, Posicao.Y + VelocidadeY*deltaTempo);
        
        EstadoTeclado = EstadoTecladoAtual;
    }

    public void Draw(SpriteBatch pintor){

        Hitbox = new Rectangle((int)Posicao.X, (int)Posicao.Y, 50, 50);
        pintor.Draw(Sprite, Hitbox, Color.White);
    }
}
namespace LD51
{
    public class PlayerAnimation
    {
        private readonly int totalAnimationFrames = 3;
        private readonly int numberOfFrames = 7;
        private int tempTimer = 0;
        private int animationFrame = 0;

        public int GetAnimationFrame()
        {
            return animationFrame;
        }

        public void AnimateCharacter()
        {
            if (tempTimer == numberOfFrames)
            {
                animationFrame++;
                if (animationFrame == totalAnimationFrames)
                {
                    animationFrame = 0;
                }
                tempTimer = 0;
            }

            tempTimer++;
        }
    }
}

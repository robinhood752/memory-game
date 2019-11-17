namespace memory_game
{
    public static class StaticRandom
    {
        private static readonly System.Random Random = new System.Random();

        public static int Next()
        {
            lock (Random)
            {
                return Random.Next();
            }
        }

        public static int Next(int maxValue)
        {
            lock (Random)
            {
                return Random.Next(maxValue);
            }
        }

        public static int Next(int minValue, int maxValue)
        {
            lock (Random)
            {
                return Random.Next(minValue, maxValue);
            }
        }
    }
}

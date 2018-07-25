namespace BowlingKata
{
    public class Game
    {
        private readonly int[] _rolls = new int[21];
        private int _currentRoll;
        private int _score;

        public void Roll(int pins)
        {
            _rolls[_currentRoll] = pins;
            _currentRoll++;
        }

        public int Score()
        {
            var rollIndex = 0;
            for(var frame = 0; frame < 10; frame++)
            {
                if (IsStrike(rollIndex))
                {
                    _score += 10 + _rolls[rollIndex + 1] + _rolls[rollIndex + 2];
                    rollIndex++;
                }
                else if (IsSpare(rollIndex))
                {
                    _score += 10 + _rolls[rollIndex + 2];
                    rollIndex += 2;
                }
                else
                {
                    _score += _rolls[rollIndex] + _rolls[rollIndex + 1];
                    rollIndex += 2;
                }
            }

            return _score;
        }

        private bool IsStrike(int rollIndex)
        {
            return _rolls[rollIndex] == 10;
        }

        private bool IsSpare(int i)
        {
            return _rolls[i] + _rolls[i + 1] == 10;
        }
    }
}

using Xunit;

namespace BowlingKata
{
    public class GameTest
    {
        private readonly Game _game;
        public GameTest()
        {
            _game = new Game();
        }

        private void RollMany(int numberRoll, int pinsKnocked)
        {
            for (var i = 0; i < numberRoll; i++)
            {
                _game.Roll(pinsKnocked);
            }
        }

        [Fact]
        public void When_AllRoll_Equals_0_Score_Should_Return_0()
        {
            RollMany(20, 0);
            Assert.Equal(0, _game.Score());
        }

        [Fact]
        public void When_AllRoll_Equals_1_Score_Should_Return_20()
        {
            RollMany(20, 1);
            Assert.Equal(20, _game.Score());
        }

        [Fact]
        public void When_FrameEquals_Spare_Score_Should_Return_16()
        {
            RollSpare();
            _game.Roll(3);

            RollMany(17, 0);
            Assert.Equal(16, _game.Score());
        }

        private void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }

        [Fact]
        public void When_FrameEquals_Strike_Score_Should_Return_24()
        {
            RollStrike();
            _game.Roll(3);
            _game.Roll(4);

            RollMany(16, 0);
            Assert.Equal(24, _game.Score());
        }

        [Fact]
        public void When_AllFrameIsStrike_Score_Should_Return_300()
        {
            RollMany(12, 10);
            Assert.Equal(300, _game.Score());
        }

        private void RollStrike()
        {
            _game.Roll(10);
        }
    }
}

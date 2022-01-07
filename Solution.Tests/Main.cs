using Solution.Solve;
using Xunit;


namespace Solution.Tests
{
	public sealed class Tests
	{
		[Theory]
		[InlineData("2:eeeee/2:yy/=:hh/=:rr", "Are they here", "yes, they are here")]
		[InlineData("1:ooo/1:uuu/2:sss/=:nnn/1:ii/2:aa/2:dd/2:ee/=:gg", "looping is fun but dangerous", "less dangerous than coding")]
		[InlineData("1:aaa/1:nnn/1:gg/2:ee/2:ff/2:ii/2:oo/2:rr/2:ss/2:tt", " In many languages", " there's a pair of functions")]
		[InlineData("1:ee/1:ll/1:oo", "Lords of the Fallen", "gamekult")]
		[InlineData("", "codewars", "codewars")]
		[InlineData("1:nnnnn/1:ooooo/1:tttt/1:eee/1:gg/1:ii/1:mm/=:rr", "A generation must confront the looming ", "codewarrs")]
		public void MixShouldReturnCorrectResult(string expected, string s1, string s2)
		{
			var result = Main.Mix(s1, s2);
			
			Assert.Equal(expected, result);
		}
	}
}
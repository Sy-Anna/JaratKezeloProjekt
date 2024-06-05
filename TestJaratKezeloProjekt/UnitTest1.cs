using JaratKezeloProjekt;

namespace TestJaratKezeloProjekt
{
	public class Tests
	{
		public void UjJarat_HelyesParameterekkel_UjJaratLetrejonne()
		{
			JaratKezelo jaratKezelo = new JaratKezelo();
			DateTime indulas = new DateTime(2024, 6, 1);

			jaratKezelo.UjJarat("ABC123", "BUD", "LHR", indulas);

			Assert.True(jaratKezelo.JaratokRepuloterrol("BUD").Contains("ABC123"));
		}
	}
}
namespace JaratKezeloProjekt
{
	public class JaratKezelo
	{
		private Dictionary<string, (string, string, DateTime, int)> jaratok = new Dictionary<string, (string, string, DateTime, int)>();

		public void UjJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
		{
			if (jaratok.ContainsKey(jaratSzam))
				throw new ArgumentException("A járatszám már létezik.");

			jaratok[jaratSzam] = (repterHonnan, repterHova, indulas, 0);
		}

		public void Keses(string jaratSzam, int keses)
		{
			if (!jaratok.ContainsKey(jaratSzam))
				throw new ArgumentException("Nem létező járat.");

			var (repterHonnan, repterHova, indulas, sumKeses) = jaratok[jaratSzam];

			if (sumKeses + keses < 0)
				throw new ArgumentException("A késés nem lehet negatív.");

			jaratok[jaratSzam] = (repterHonnan, repterHova, indulas, sumKeses + keses);
		}

		public DateTime MikorIndul(string jaratSzam)
		{
			if (!jaratok.ContainsKey(jaratSzam))
				throw new ArgumentException("Nem létező járat.");

			var (repterHonnan, repterHova, indulas, sumKeses) = jaratok[jaratSzam];
			return indulas.AddMinutes(sumKeses);
		}

		public List<string> JaratokRepuloterrol(string repter)
		{
			var jaratokRepuloterrol = jaratok.Where(j => j.Value.Item1 == repter).Select(j => j.Key).ToList();
			return jaratokRepuloterrol;
		}
	}
}
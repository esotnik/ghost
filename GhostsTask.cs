using System;
using System.Text;

namespace hashes
{
	public class GhostsTask :
		IFactory<Document>, IFactory<Vector>, IFactory<Segment>, IFactory<Cat>, IFactory<Robot>,
		IMagic
	{
		Cat cat = new Cat("Cat007", "breed", DateTime.Parse("01.01.2006"));
		Vector vector = new Vector(1, 1);
		Segment segment = new Segment(new Vector(0, 1), new Vector(1, 0));
		byte[] content;
		Document document;
		Robot robot = new Robot("001");

		public GhostsTask()
		{ // создаём недосозданный документ ибо он зависит от поля content
			var encoding = Encoding.UTF8;
			content = encoding.GetBytes("Hello World");
			document = new Document("Unnamed1", encoding, content);
		}
		
		public void DoMagic()
		{
			cat.Rename("Cat");
			vector.Add(new Vector(8, 0));
			segment.Start.Add(vector);
			//content = UTF8Encoding.ASCII.GetBytes("Buy World");
			for (var i = 0; i < content.Length; i++)
				++content[i];
			Robot.BatteryCapacity /= 2; // потому что static
		}

		// Чтобы класс одновременно реализовывал интерфейсы IFactory<A> и IFactory<B> 
		// придется воспользоваться так называемой явной реализацией интерфейса.
		// Чтобы отличать методы создания A и B у каждого метода Create нужно явно указать, к какому интерфейсу он относится.
		// На самом деле такое вы уже видели, когда реализовывали IEnumerable<T>.
		
		Vector IFactory<Vector>.Create()
		{
			return vector;
		}

		Segment IFactory<Segment>.Create()
		{
			return segment;
		}

		Document IFactory<Document>.Create()
		{
			return document;
		}

		Cat IFactory<Cat>.Create()
		{
			return cat;
		}

		Robot IFactory<Robot>.Create()
		{
			return robot;
		}
	}
}
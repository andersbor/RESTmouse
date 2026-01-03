namespace RESTmouse.Model
{
    public class MouseRepository
    {
        private List<Mouse> mice = new List<Mouse>();
        private int nextId = 1;

        public MouseRepository()
        {
            // Seed with some initial data
            mice.Add(new Mouse { Id = nextId++, Wireless = false, Color = "Black" });
            mice.Add(new Mouse { Id = nextId++, Wireless = true, Color = "White" });
        }

        public IEnumerable<Mouse> GetAll()
        {
            return new List<Mouse>(mice);
        }

        public Mouse? GetById(int id)
        {
            return mice.FirstOrDefault(m => m.Id == id);
        }

        public Mouse Add(Mouse mouse)
        {
            mouse.Id = nextId++;
            mice.Add(mouse);
            return mouse;
        }

        public bool Update(int id, Mouse updatedMouse)
        {
            var existingMouse = GetById(id);
            if (existingMouse == null)
            {
                return false;
            }
            existingMouse.Wireless = updatedMouse.Wireless;
            existingMouse.Color = updatedMouse.Color;
            return true;
        }

        public bool Delete(int id)
        {
            var mouse = GetById(id);
            if (mouse == null)
            {
                return false;
            }
            mice.Remove(mouse);
            return true;
        }
    }
}

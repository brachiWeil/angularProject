namespace aaa
{
    public class Recipe
    {
        public int Id { get; set; }
        public int RecipeCode { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int PreparationTime { get; set; }
        public int Difficulty { get; set; }
        //public DateTime creationDate { get; set; }

        public string[] Ingredients { get; set; }
        public string[] Instructions { get; set; }
        public int UserId { get; set; }
        public string Image { get; set; }

        public Recipe()
        {
            Ingredients = new string[] { };
            Instructions = new string[] { };
        }
        private readonly List<Recipe> recipes;

      
    }
}

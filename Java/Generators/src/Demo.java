public class Demo {
   public static void main(String[] args) {
      System.out.println("Constructing range");
      RangeGenerator range = new RangeGenerator(1, 14);
      System.out.println("Constructing filter");
      Generator<Integer> filter = 
         new FilterGenerator<Integer>(
            (i) -> i % 5 == 0, 
            range);
      
      System.out.println("Constructing map");
      Generator<Double> map =
         new MapGenerator<Integer, Double>(
            (i) -> Math.sqrt(i),
            filter);
      
      while (map.hasNext()) {
         System.out.println(map.next());
      }
   }
}

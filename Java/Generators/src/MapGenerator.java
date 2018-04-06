public class MapGenerator<TIn, TOut> implements Generator<TOut> {
   private MapFunction<TIn, TOut> mTransform;
   private Generator<TIn> mSource;
   
   public MapGenerator(MapFunction<TIn, TOut> transform, Generator<TIn> source) {
      mTransform = transform;
      mSource = source;
   }
   
   public boolean hasNext() {
      return mSource.hasNext();
   }
   
   public TOut next() {
      return mapNext();
   }
   
   private TOut mapNext() {
      TIn  next = mSource.next();
      TOut transformed = mTransform.transform(next);
      System.out.println("Transformed: " + next + " to " + transformed);
      return transformed;
   }
}

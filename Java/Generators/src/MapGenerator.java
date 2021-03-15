import java.util.Iterator;
import java.util.function.Function;

public class MapGenerator<TIn, TOut> implements Iterable<TOut> {
   private Function<TIn, TOut> mTransform;
   private Iterable<TIn> mSource;
   
   public MapGenerator(Function<TIn, TOut> transform, Iterable<TIn> source) {
      mTransform = transform;
      mSource = source;
   }

   public Iterator<TOut> iterator() {
      return new MapIterator();
   }

   private class MapIterator implements Iterator<TOut> {
      private Iterator<TIn> mIter;

      public MapIterator() {
         mIter = mSource.iterator();
      }

      public boolean hasNext() {
         return mIter.hasNext();
      }
      
      public TOut next() {
         TIn  next = mIter.next();
         TOut transformed = mTransform.apply(next);
         System.out.println("Transformed: " + next + " to " + transformed);
         return transformed;
      }
   }

}
import java.util.function.Predicate;
public class FilterGenerator<T> implements Generator<T> {
   private Generator<T> mSource;
   private Predicate<T> mPredicate;
   private T mNext;
   
   public FilterGenerator(Predicate<T> pred, Generator<T> source) {
      mSource = source;
      mPredicate = pred;
      
      mNext = findNext();
   }
   
   private T findNext() {
      while (mSource.hasNext()) {
         T temp = mSource.next();
         if (mPredicate.test(temp)) {
            return temp;
         }
      }
      return null;
   }
   public boolean hasNext() {
      return mNext != null;
   }
   
   public T next() {
      T temp = mNext;
      System.out.println("Filtered: " + temp);
      mNext = findNext();
      return temp;
   }
}

import java.util.function.Predicate;

public class Seq {
    public static <T> Iterable<T> filter(Predicate<T> pred, Iterable<T> source) {
        return new FilterGenerator<>(pred, source);
    }

    public static <T> Iterable<T> take(int n, Iterable<T> source) {
        return new TakeGenerator<>(n, source);
    }

    public static <TIn, TOut> Iterable<TOut> map(MapFunction<TIn, TOut> mapper, Iterable<TIn> source) {
        return new MapGenerator<>(mapper, source);
    }
    
    public static Iterable<Integer> range(int start, int end) {
        return new RangeGenerator(start, end);
    }
}
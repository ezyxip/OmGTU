formula :: Int -> Int
l = 7
n = 5
m = 10
formula k = k * (2 * (l + m + n) + m*(k-1))

myCycle::Int->Int
myCycle k = if k == 0 then 0 else 2*(l+m+n+m*(k-1)) + myCycle (k-1)

main = do
        putStrLn(show(formula 1))
        putStrLn(show(formula 2))
        putStrLn(show(formula 3))
        putStrLn(show(formula 20))

        putStrLn(show(myCycle 1))
        putStrLn(show(formula 2))
        putStrLn(show(formula 3))
        putStrLn(show(formula 20))
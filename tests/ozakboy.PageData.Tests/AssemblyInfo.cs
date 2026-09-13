// 測試彼此之間沒有共用狀態，明確開啟方法層級的平行執行(MSTEST0001 要求明確表態)。
// The tests share no state, so parallelisation is explicitly enabled at method level.
[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]

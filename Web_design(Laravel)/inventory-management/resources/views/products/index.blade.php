@extends('layouts.app')

@section('content')
<div class="container">
    <div class="d-flex justify-content-between align-items-center mb-4">
        <h1 class="mb-0">مدیریت محصولات انبار</h1>
        <a href="{{ route('products.create') }}" class="btn btn-success">
            <i class="fas fa-plus"></i> افزودن محصول جدید
        </a>
    </div>

    @if(session('success'))
        <div class="alert alert-success alert-dismissible fade show">
            {{ session('success') }}
            <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
        </div>
    @endif

    @if($products->isEmpty())
        <div class="alert alert-info">
            هیچ محصولی ثبت نشده است.
        </div>
    @else
        <div class="table-responsive">
            <table class="table table-striped table-hover">
                <thead class="table-dark">
                    <tr>
                        <th>#</th>
                        <th>نام محصول</th>
                        <th>دسته‌بندی</th>
                        <th>موجودی</th>
                        <th>قیمت واحد (تومان)</th>
                        <th>عملیات</th>
                    </tr>
                </thead>
                <tbody>
                    @foreach($products as $index => $product)
                    <tr>
                        <td>{{ $index + 1 }}</td>
                        <td>{{ $product->name }}</td>
                        <td>
                            <span class="badge bg-primary">
                                {{ $product->category }}
                            </span>
                        </td>
                        <td @if($product->quantity < 10) class="text-danger fw-bold" @endif>
                            {{ $product->quantity }}
                            @if($product->quantity < 10)
                                <small class="text-muted">(کمبود موجودی)</small>
                            @endif
                        </td>
                        <td>{{ number_format($product->price_per_unit) }}</td>
                        <td>
                            <div class="btn-group btn-group-sm">
                                <a href="{{ route('products.show', $product->id) }}" 
                                   class="btn btn-info" title="نمایش">
                                    <i class="fas fa-eye"></i>
                                </a>
                                <a href="{{ route('products.edit', $product->id) }}" 
                                   class="btn btn-warning" title="ویرایش">
                                    <i class="fas fa-edit"></i>
                                </a>
                                <form action="{{ route('products.destroy', $product->id) }}" 
                                      method="POST" class="d-inline">
                                    @csrf
                                    @method('DELETE')
                                    <button type="submit" class="btn btn-danger" 
                                            title="حذف" onclick="return confirm('آیا از حذف این محصول مطمئن هستید؟')">
                                        <i class="fas fa-trash"></i>
                                    </button>
                                </form>
                            </div>
                        </td>
                    </tr>
                    @endforeach
                </tbody>
            </table>
        </div>
        
        <!-- صفحه‌بندی -->
        {{ $products->links() }}
    @endif
</div>
@endsection
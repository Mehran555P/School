@extends('layouts.app')

@section('content')
<div class="container">
    <div class="row justify-content-center">
        <div class="col-md-8">
            <div class="card">
                <div class="card-header bg-info text-white">
                    <h3 class="mb-0">جزئیات محصول</h3>
                </div>

                <div class="card-body">
                    <div class="row mb-4">
                        <div class="col-md-4 fw-bold">نام محصول:</div>
                        <div class="col-md-8">{{ $product->name }}</div>
                    </div>

                    <div class="row mb-4">
                        <div class="col-md-4 fw-bold">دسته‌بندی:</div>
                        <div class="col-md-8">
                            <span class="badge bg-primary">{{ $product->category }}</span>
                        </div>
                    </div>

                    <div class="row mb-4">
                        <div class="col-md-4 fw-bold">موجودی:</div>
                        <div class="col-md-8">
                            {{ $product->quantity }}
                            @if($product->quantity < 10)
                                <span class="badge bg-danger">کمبود موجودی</span>
                            @endif
                        </div>
                    </div>

                    <div class="row mb-4">
                        <div class="col-md-4 fw-bold">قیمت هر واحد:</div>
                        <div class="col-md-8">{{ number_format($product->price_per_unit) }} تومان</div>
                    </div>

                    <div class="row mb-4">
                        <div class="col-md-4 fw-bold">ارزش کل موجودی:</div>
                        <div class="col-md-8">{{ number_format($product->quantity * $product->price_per_unit) }} تومان</div>
                    </div>

                    <div class="d-flex justify-content-end">
                        <a href="{{ route('products.edit', $product->id) }}" class="btn btn-warning me-2">
                            <i class="fas fa-edit"></i> ویرایش
                        </a>
                        <form action="{{ route('products.destroy', $product->id) }}" method="POST">
                            @csrf
                            @method('DELETE')
                            <button type="submit" class="btn btn-danger" onclick="return confirm('آیا مطمئن هستید؟')">
                                <i class="fas fa-trash"></i> حذف
                            </button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
@endsection